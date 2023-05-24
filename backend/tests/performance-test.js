import { sleep } from 'k6';
import http from 'k6/http';

export const options = {
    duration: '5s',
    vus: 10,
    thresholds: {
        http_req_duration: ['p(95)<700'],
    },
};

export default function () {
    http.get('http://localhost:8081/courses');
    sleep(3);
}