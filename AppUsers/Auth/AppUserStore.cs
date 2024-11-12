using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TaskApiSample.AppUsers.Models;

namespace TaskApiSample.AppUsers.Auth;

public class AppUserStore(OurTaskContext context) : IUserPasswordStore<AppUser>
{
    public async Task<IdentityResult> CreateAsync(AppUser user, CancellationToken cancellationToken)
    {
        string validationError = user.Validate();
        if(string.IsNullOrEmpty(validationError) == false)
        {
            return IdentityResult.Failed(new IdentityError { Description = validationError });
        }
        using IDbContextTransaction transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        if(await context.AppUsers
                .AnyAsync(u => u.Email == user.Email, cancellationToken: cancellationToken))
        {
            return IdentityResult.Failed(new IdentityError { Description = "Your e-mail address is already used" });
        }
        await context.AppUsers.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return IdentityResult.Success;
    }

    public async Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken)
    {
        using IDbContextTransaction transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        AppUser? target = await context.AppUsers
                .FirstOrDefaultAsync(u => u.Id == user.Id,
                cancellationToken);
        if(target == null)
        {
            return IdentityResult.Success;
        }
        context.AppUsers.Remove(target);
        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return IdentityResult.Success;
    }

    public void Dispose() { /* do nothing */ }

    public async Task<AppUser?> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        Console.WriteLine($"FindByIdAsync");
        if(int.TryParse(userId, out var id) == false)
        {
            return null;
        }
        return await context.AppUsers
            .FirstOrDefaultAsync(u => u.Id == id,
            cancellationToken);
    }

    public async Task<AppUser?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        // Use e-mail
        return await context.AppUsers
                .FirstOrDefaultAsync(u => string.IsNullOrEmpty(u.Email) == false && u.Email == normalizedUserName,
                cancellationToken);
    }

    public async Task<string?> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken)
    {
        Console.WriteLine($"GetNormalizedUserNameAsync");
        return await Task.FromResult(user.NormalizedUserName);
    }

    public async Task<string?> GetPasswordHashAsync(AppUser user, CancellationToken cancellationToken)
    {
        Console.WriteLine($"GetPasswordHashAsync");
        return await Task.FromResult(user.PasswordHash);
    }

    public async Task<string> GetUserIdAsync(AppUser user, CancellationToken cancellationToken)
    {
        Console.WriteLine($"GetUserIdAsync");
        return await Task.FromResult(user.Id.ToString());
    }

    public async Task<string?> GetUserNameAsync(AppUser user, CancellationToken cancellationToken)
    {
        Console.WriteLine($"GetUserNameAsync");
        return await Task.FromResult(user.UserName);
    }

    public async Task<bool> HasPasswordAsync(AppUser user, CancellationToken cancellationToken)
    {
        return await Task.FromResult(true);
    }

    public async Task SetNormalizedUserNameAsync(AppUser user, string? normalizedName, CancellationToken cancellationToken)
    {
        // do nothing
        await Task.Run(() => {}, cancellationToken);
    }

    public async Task SetPasswordHashAsync(AppUser user, string? passwordHash, CancellationToken cancellationToken)
    {
        using IDbContextTransaction transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        AppUser? target = await context.AppUsers
                .FirstOrDefaultAsync(u => u.Id == user.Id,
                cancellationToken);
        if(target == null)
        {
            return;
        }
        target.UpdatePassword(passwordHash);
        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }

    public async Task SetUserNameAsync(AppUser user, string? userName, CancellationToken cancellationToken)
    {
        using IDbContextTransaction transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        AppUser? target = await context.AppUsers
                .FirstOrDefaultAsync(u => u.Id == user.Id,
                cancellationToken);
        if(target == null)
        {
            return;
        }        
        target.UpdatePassword(userName);
        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
    }

    public async Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken)
    {
        string validationError = user.Validate();
        if(string.IsNullOrEmpty(validationError) == false)
        {
            return IdentityResult.Failed(new IdentityError { Description = validationError });
        }
        using IDbContextTransaction transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        AppUser? target = await context.AppUsers
                .FirstOrDefaultAsync(u => u.Id == user.Id,
                cancellationToken);
        if(target == null)
        {
            return IdentityResult.Failed([new IdentityError{ Description = "User was not found" }]);
        }
        target.Update(user);
        await context.SaveChangesAsync(cancellationToken);
        await transaction.CommitAsync(cancellationToken);
        return IdentityResult.Success;
    }
}