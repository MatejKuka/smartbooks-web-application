import {TableCell} from "@mui/material";
import React from "react";

type propsType = {
    name: string
}

function TableItemName({name}): React.FC<propsType> {
    return (
        <TableCell
            sx={{
                fontSize: "1.2rem",
                color: "blue",
                fontWeight: "bolder"
            }}
            align={"center"}
            component="th"
            scope="row">
            {name}
        </TableCell>
    );
}

export default React.memo(TableItemName);