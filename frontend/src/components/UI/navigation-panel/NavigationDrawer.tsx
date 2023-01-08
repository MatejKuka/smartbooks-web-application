import {Drawer} from "@mui/material";
import React from "react";

type navigationDrawerType = {
    isOpen: boolean,
    setClose: (toClose: boolean) => void
}

const DRAWER_ITEMS = [
    "Zadané úlohy",
    "Moje učenie",
    "Štatistiky učenia",
    "Sieň slávy",
    "Moje licencie",
    "Odhlásiť sa",]

function NavigationDrawer(props: navigationDrawerType) {

    return (
        <Drawer
            anchor={"left"}
            open={props.isOpen}
            onClose={() => props.setClose(false)}>
            {DRAWER_ITEMS.map(
                item => <p
                    key={item}
                    className={"p-4 "}
                >{item}</p>
            )}
        </Drawer>
    );
}

export default React.memo(NavigationDrawer);