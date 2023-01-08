interface Course {
    map(arg0: (course: any) => JSX.Element): import("react").ReactNode;
    id: number,
    title: string
}


export default Course