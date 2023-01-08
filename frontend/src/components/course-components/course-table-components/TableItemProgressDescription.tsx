import React from "react";

type propsType = {
    progress: number
}

function TableItemProgressDescription({progress}): React.FC<propsType> {

    if (progress === 0) {
        return (
            <div className={"shadow-md shadow-orange-400 flex justify-between p-2 max-w-[200px] mx-auto rounded"}>
                <div className={"rounded-[50%] w-[20px] h-[20px] bg-orange-400"}/>
                <p>Nezačaté</p>
                <p>{progress}%</p>
            </div>
        );
    }
    if (progress === 100) {
        return (
            <div className={"shadow-md shadow-blue-400 flex justify-between p-2 max-w-[200px] mx-auto rounded"}>
                <div className={"rounded-[50%] w-[20px] h-[20px] bg-blue-400"}/>
                <p>Dokončené</p>
                <p>{progress}%</p>
            </div>
        );
    }

    return (
        <div className={"shadow-md shadow-yellow-400 flex justify-between p-2 max-w-[200px] mx-auto rounded"}>
            <div className={"rounded-[50%] w-[20px] h-[20px] bg-yellow-400"}/>
            <p>In progress</p>
            <p>{progress}%</p>
        </div>
    );
}

export default React.memo(TableItemProgressDescription);