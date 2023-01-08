import React from 'react';
import {CircularProgress, LinearProgress} from "@mui/material";

type PropsType = {
    children?: any,
    isLoading: boolean,
    isError: boolean,
    loadingType: "circular" | "linear"
}

function QueryResult({children, isLoading, isError, loadingType}): React.FC<PropsType> {

    if(isLoading && loadingType === "circular")
        return (
            <CircularProgress/>
        )

    if(isLoading && loadingType === "linear")
        return (
            <LinearProgress/>
        )

    if(isError)
        return (
            <h2>Error :(</h2>
        )

    return children;
}

export default React.memo(QueryResult);