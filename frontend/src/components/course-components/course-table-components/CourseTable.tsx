import {Button, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow} from "@mui/material";
// @ts-ignore
import TableItemName from "./TableItemName.tsx";
// @ts-ignore
import TableItemProgress from "./TableItemProgress.tsx";
// @ts-ignore
import TableItemScore from "./TableItemScore.tsx";
import React from "react";
import PersonalStatistics from "../../../types/PersonalStatistics";

type PropsType = {
    personalStatistics: PersonalStatistics[]
}

const TABLE_TITLES = ["Názov a predmet", "Progres", "Score", "Akcia"];

function CourseTable({personalStatistics}): React.FC<PropsType> {

    return (
        <div className={"bg-amber-700"}>
            <TableContainer component={Paper}>
                <Table aria-label="course-table">
                    <TableHead>
                        <TableRow>
                            {TABLE_TITLES.map(title => (
                                <TableCell
                                    key={title}
                                    align="center">{title}
                                </TableCell>
                            ))}
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {personalStatistics?.map((row) => (
                            <TableRow
                                key={row.id}
                                sx={{'&:last-child td, &:last-child th': {border: 0}}}
                            >
                                <TableItemName
                                    name={row.lesson.title}
                                />
                                <TableItemProgress
                                    progress={row.progress}
                                />
                                <TableItemScore
                                    score={row.score}
                                />
                                <TableCell align="center">
                                    <Button
                                        variant={"contained"}
                                        key={row.name}
                                    >Pokračuj
                                    </Button>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    );
}

export default React.memo(CourseTable);