import React, {createContext, ReactNode, useEffect, useState} from "react";
import PersonalStatistics from "../types/PersonalStatistics";
import {useQuery} from "react-query";
// @ts-ignore
import ApiResponse from "../types/ApiResponse.ts";
// @ts-ignore
import myAxios from "../api/index.ts";

type ContextProps = {
    children: ReactNode
}

interface PersonalStatisticsTypes {
    currentPersonalStatistics: PersonalStatistics[] | null,
    fetchData: (courseId: number) => void,
    isLoading: boolean,
    isError: boolean
}

const personalStatisticsContext = createContext<PersonalStatisticsTypes>({
    currentPersonalStatistics: null,
    fetchData: () => {},
    isLoading: false,
    isError: false
});

export const PersonalStatisticsProvider: React.FC<ContextProps> = (props) => {
    const [currentCourseId, setCurrentCourseId] = useState<number>(1);
    const [currentPersonalStatistics, setcurrentPersonalStatistics] = useState<PersonalStatistics[]>();
    const {data, isLoading, isError} = useQuery<ApiResponse>(
        ["personalStatistics", currentCourseId], () =>
            myAxios.get(`personalstatistics/lesson/${currentCourseId}`)

    );

    const fetchData = (courseId: number) => {
        setCurrentCourseId(courseId);
    }

    useEffect(() => {
        if (data?.data) {
            setcurrentPersonalStatistics(data?.data);
        }
    }, [data])

    const contextValues: PersonalStatisticsTypes = {
        currentPersonalStatistics,
        fetchData,
        isError,
        isLoading
    }

    return (
        <personalStatisticsContext.Provider value={contextValues}>
            {props.children}
        </personalStatisticsContext.Provider>
    )
}

export default personalStatisticsContext;