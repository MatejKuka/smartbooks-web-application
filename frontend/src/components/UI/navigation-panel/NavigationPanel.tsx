import {useState} from "react";
import {Avatar, Button} from "@mui/material";
// @ts-ignore
import NavigationDrawer from "./NavigationDrawer.tsx";
import React from "react";

type userPropsType = {
    userImagePath: string,
    userName: string
}

function NavigationPanel(props: userPropsType) {
    const [isOpenDrawer, setOpenDrawer] = useState<boolean>(false);

    return (
        <div className={"bg-blue-100 w-full h-14 flex items-center drop-shadow-xl justify-between px-2"}>
            <Button
                variant={"contained"}
                onClick={() => setOpenDrawer(true)}>Open Drawer
            </Button>
            <div className={"flex items-center gap-2"}>
                <NavigationDrawer
                    isOpen={isOpenDrawer}
                    setClose={toClose => setOpenDrawer(toClose)}
                />
                <p>{props.userName}</p>
                <Avatar src={props.userImagePath}/>
                <Button variant={"contained"}>Log out</Button>
            </div>
        </div>
    );
}

export default React.memo(NavigationPanel);
//This navigation panel is mounted when a user is successfully logged in