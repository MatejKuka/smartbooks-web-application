import {Button} from "@mui/material";
import React from "react";

type propsType = {
    routePath: string,
    name: string
}

function CourseSwitcherButton({routePath, name}): React.FC<propsType> {

    return (
        <a href={`/${routePath}`}>
            <Button
                sx={{
                    width: "100%"
                }}
                variant={"contained"}>{name}</Button>
        </a>

    );
}

export default React.memo(CourseSwitcherButton);