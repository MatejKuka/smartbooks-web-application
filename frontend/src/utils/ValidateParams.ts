import Course from "../types/Course";

function ValidateParams(arrayToCheck: Course[], courseId: string) {
    return arrayToCheck?.find(c => c.id.toString() === courseId)
}


export default ValidateParams;