import React from "react";

type propsType = {
    score: number
}

function TableItemScoreDescription({score}): React.FC<propsType> {

    if (score === null || score === 0) {
        return (
            <>
                <div className={"text-xl"}>- - -</div>
            </>
        );
    }

    if (score >= 85 && score <= 100) {
        return (
            <>
                <div className={"text-xl font-semibold text-blue-500"}>{score}%</div>
                <div>Výborný</div>
            </>
        );
    }

    return (
        <>
            <div className={"text-xl font-semibold text-orange-500"}>{score}%</div>
            <div>Nepostačujúci</div>
        </>
    );
}

export default React.memo(TableItemScoreDescription);