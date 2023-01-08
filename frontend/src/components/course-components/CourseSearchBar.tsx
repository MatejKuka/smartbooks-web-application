import {useRef} from "react";
import React from "react";

type propsType = {
    searchedPhrase: (phrase: string) => void
}

function CourseSearchBar({searchedPhrase}): React.FC<propsType> {
    const searchFieldInputRef = useRef<HTMLInputElement>();

    return (
        <div className={"w-full rounded h-20 flex justify-center items-center"}>
                <input
                    placeholder={"Hľadajte názov lekcie"}
                    className={"bg-gray-300 p-1"}
                    ref={searchFieldInputRef}
                    onChange={()=> searchedPhrase(searchFieldInputRef.current!.value)}
                />
        </div>
    );
}

export default React.memo(CourseSearchBar);