// @ts-ignore
import CourseMenuComponent from "../components/course-components/CourseMenuComponent.tsx";
// @ts-ignore
import myAxios from "../api/index.ts";
import {useContext} from "react";
// @ts-ignore
import coursesContext from "../context/courses-context.tsx";
import QueryResult from "../components/functional-components/QueryResult.tsx";

function UserCoursesMenu() {
    const {currentCourses, isError, isLoading} = useContext(coursesContext);

    return (
        <QueryResult
            isError={isError}
            isLoading={isLoading}
            loadingType={"linear"}
        >
            <div className={"h-auto mt-6 flex flex-wrap justify-center"}>
                {currentCourses ? currentCourses.map(course => (
                    <CourseMenuComponent
                        key={course.id}
                        routePath={course.id.toString()}
                        title={course.title}
                    />)) : <h1>No courses assigned yet</h1>}
            </div>
        </QueryResult>
    );
}

export default UserCoursesMenu;