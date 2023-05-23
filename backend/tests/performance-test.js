import { sleep } from 'k6';
import http from 'k6/http';

export const options = {
    duration: '1m',
    vus: 50,
};

export default function () {
    http.get('http://test.k6.io/contacts.php');
    sleep(3);
}