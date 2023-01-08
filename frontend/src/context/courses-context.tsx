import React, {createContext, ReactNode, useEffect, useState} from "react";
import Course from "../types/Course";
import {useQuery} from "react-query";
// @ts-ignore
import ApiResponse from "../types/ApiResponse.ts";
// @ts-ignore
import myAxios from "../api/index.ts";

type ContextProps = {
    children: ReactNode
}

interface CoursesContextTypes {
    currentCourses: Course[] | null,
    isLoading: boolean,
    isError: boolean,
}

const coursesContext = createContext<CoursesContextTypes>({
    currentCourses: null,
    isLoading: false,
    isError: false,
});

export const CoursesContextProvider: React.FC<ContextProps> = (props) => {
    const [currentCourses, setCurrentCourses] = useState<Course[]>();
    const {data, isLoading, isError} = useQuery<ApiResponse>("courses", () =>
        myAxios.get("courses")
    );

    useEffect(() => {
        if (data?.data) {
            setCurrentCourses(data?.data);
        }
    }, [data?.data])


    const contextValues: CoursesContextTypes = {
        currentCourses,
        isError,
        isLoading
    }

    return (
        <coursesContext.Provider value={contextValues}>
            {props.children}
        </coursesContext.Provider>
    );
}

export default coursesContext;