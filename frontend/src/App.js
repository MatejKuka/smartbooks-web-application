import NotFoundPage from "./pages/NotFoundPage.tsx";
import UserMainMenuPage from "./pages/UserMainMenuPage.tsx";
import UserCoursesMenu from './pages/UserCoursesMenu.tsx';
import {Route, Routes} from "react-router-dom";


function App() {

    return (
        <div>
            <Routes>
                <Route path="/" element={<UserCoursesMenu/>}/>
                <Route path="/:courseId" element={<UserMainMenuPage/>}/>
                <Route path="*" element={<NotFoundPage/>}/>
            </Routes>
        </div>
    );
}

export default App;
