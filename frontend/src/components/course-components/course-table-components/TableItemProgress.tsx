import {TableCell} from "@mui/material";
// @ts-ignore
import TableItemProgressDescription from "./TableItemProgressDescription.tsx";
import React from "react";

type propsType = {
    progress: number
}

function TableItemProgress({progress}): React.FC<propsType> {
    return (
        <TableCell align="center">
            <TableItemProgressDescription
                progress={progress}
            />
        </TableCell>
    );
}

export default React.memo(TableItemProgress);