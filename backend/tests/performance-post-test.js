import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    stages: [
        { duration: '20s', target: 20 },
        { duration: '10s', target: 10 },
        { duration: '15s', target: 15 },
    ],
};
export default function () {
    const res = http.post("http://localhost:8081/courses", {body: {title: "test"}});
    check(res, { 'status was 200': (r) => r.status === 200 });
    sleep(1);
}