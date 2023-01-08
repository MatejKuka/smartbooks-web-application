import {TableCell} from "@mui/material";
// @ts-ignore
import TableItemScoreDescription from "./TableItemScoreDescription.tsx";
import React from "react";

type propsType = {
    score: number
}

function TableItemScore({score}): React.FC<propsType> {
    return (
        <TableCell align="center">
            <TableItemScoreDescription
                score={score}
            />
        </TableCell>
    );
}

export default React.memo(TableItemScore);