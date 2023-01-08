// @ts-ignore
import NavigationPanel from "../components/UI/navigation-panel/NavigationPanel.tsx";
// @ts-ignore
import USER_DEMO_IMAGE from "../assets/avatar-user-image.jpg";
// @ts-ignore
import CourseHandler from "../components/course-components/CourseHandler.tsx";
import {useParams} from "react-router-dom";
// @ts-ignore
import {PersonalStatisticsProvider} from "../context/personalStatistics-context.tsx";
import React, {useContext} from "react";
import coursesContext from "../context/courses-context.tsx";
import ValidateParams from "../utils/ValidateParams.ts";
import QueryResult from "../components/functional-components/QueryResult.tsx";

function UserMainMenuPage() {
    const params = useParams();
    const {currentCourses, isLoading, isError} = useContext(coursesContext)

    const validateParamsCourseId: boolean = ValidateParams(currentCourses, params.courseId);

    if (!validateParamsCourseId)
        return (
            <h1>Nothing was found!</h1>
        )

    return (
        <QueryResult
            isLoading={isLoading}
            isError={isError}
            loadingType={"linear"}
        >
            <>
                <NavigationPanel
                    userImagePath={USER_DEMO_IMAGE}
                    userName={"Ján Hraško"}
                />
                <PersonalStatisticsProvider>
                    <CourseHandler
                        courseId={params.courseId}
                    />
                </PersonalStatisticsProvider>
            </>
        </QueryResult>

    );
}

export default UserMainMenuPage;