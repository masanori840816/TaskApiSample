import "./App.css";
import {
  BrowserRouter as Router,
  Route,
  Routes,
  Link
} from "react-router-dom";
import { IndexPage } from "./Index.page";
import { AppUserProvider } from "./users/AppUserProvider";

function App() {
  return (
    <>
      <div className="w-full h-screen flex flex-col items-center justify-center">
        <div className="w-[86%] h-[90%] bg-[green]">
          <AppUserProvider>
            <Router>
              <Link to="/">TOP</Link>
              <Routes>
                <Route path="/" element={<IndexPage />} />
              </Routes>
            </Router>
          </AppUserProvider>
        </div>
      </div>     
    </>
  )
}

export default App