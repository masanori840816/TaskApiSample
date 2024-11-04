export type AppUser = {
    name: string,
};
export async function loadAppUser(): Promise<AppUser> {
    return fetch("http://localhost:5155/appusers", {
        mode: "cors",
        method: "GET",
    })
    .then(res => res.json())
    .then(res => JSON.parse(JSON.stringify(res)));
}