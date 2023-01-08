import {Link} from "react-router-dom";
import React from "react";

type propsType = {
    routePath: string,
    title: string
}

function CourseMenuComponent({routePath, title}):React.FC<propsType> {


    return (
        <Link to={`/${routePath}`}>
            <div className={"rounded-2xl bg-amber-300 w-[200px] h-[100px] m-2 flex justify-center items-center"}>
                <h1 className={"text-xl font-semibold"}>
                    {title}
                </h1>
            </div>
        </Link>

    );
}

export default React.memo(CourseMenuComponent);