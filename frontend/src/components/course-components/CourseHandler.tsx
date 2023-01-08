// @ts-ignore
import CourseSearchBar from "./CourseSearchBar.tsx";
// @ts-ignore
import CourseTable from "./course-table-components/CourseTable.tsx";
// @ts-ignore
import {DATA_COURSES} from "../../mock-data/lessons-data.ts";
// @ts-ignore
import CourseSwitcherButton from "./CourseSwitcherButton.tsx";
import {CircularProgress, Grid} from "@mui/material";
import {useQuery} from "react-query";
// @ts-ignore
import myAxios from "../../api/index.ts";
import ApiResponse from "../../types/ApiResponse";
import React, {useContext, useEffect, useState} from "react";
// @ts-ignore
import coursesContext from "../../context/courses-context.tsx";
// @ts-ignore
import personalStatisticsContext from "../../context/personalStatistics-context.tsx";
import FilteredPSArrayBySearchedPhrase from "../../utils/SearchFilter.ts";
import QueryResult from "../functional-components/QueryResult.tsx";

type PropsType = {
    courseId: number
}


function CourseHandler({courseId}): React.FC<PropsType> {
    const {currentCourses, isError: isCourseError, isLoading: isCourseLoading} = useContext(coursesContext)
    const {currentPersonalStatistics, fetchData, isError, isLoading} = useContext(personalStatisticsContext)
    const [searchedPhrase, setSearchedPhrase] = useState<string>("");

    useEffect(() => {
        fetchData(courseId);
    }, [])

    const filteredPS = FilteredPSArrayBySearchedPhrase(currentPersonalStatistics, searchedPhrase);

    return (
        <div className={"mx-auto max-w-[1400px] mt-8"}>
            <Grid container spacing={0}>
                <Grid item sm={10}>
                    <div className={"bg-gray-100 h-[35rem] ml-auto max-w-5xl rounded"}>
                        <CourseSearchBar
                            searchedPhrase={phrase => setSearchedPhrase(phrase)}
                        />
                        <QueryResult
                            isLoading={isLoading}
                            isError={isError}
                            loadingType={"circular"}
                        >
                            <CourseTable
                                personalStatistics={filteredPS}
                            />
                        </QueryResult>
                    </div>
                </Grid>
                <Grid item sm={2}>
                    <div className={"h-full w-[6rem] flex justify-start flex-col gap-8 items-start pt-10"}>
                        <QueryResult
                            isLoading={isCourseLoading}
                            isError={isCourseError}
                            loadingType={"circular"}
                        >
                            {currentCourses.map(course => (
                                <CourseSwitcherButton
                                    key={course.id}
                                    routePath={course.id}
                                    name={course.title}
                                />
                            ))}
                        </QueryResult>
                    </div>
                </Grid>
            </Grid>
        </div>


    );
}

export default React.memo(CourseHandler);