import Lesson from "./Lesson";
import PersonalStatistics from "./PersonalStatistics";
import Course from "./Course";

interface ApiResponse {
    data: Lesson[] | PersonalStatistics[] | Course[];
    status: number;
    statusText: string;
    headers: Headers;
    config: Config;
    request: Request;
}

interface Headers {
    contentType: string;
}

interface Transitional {
    silentJSONParsing: boolean;
    forcedJSONParsing: boolean;
    clarifyTimeoutError: boolean;
}

interface Headers2 {
    Accept: string;
}

interface Config {
    transitional: Transitional;
    adapter: string[];
    transformRequest: any[];
    transformResponse: any[];
    timeout: number;
    xsrfCookieName: string;
    xsrfHeaderName: string;
    maxContentLength: number;
    maxBodyLength: number;
    env: any;
    headers: Headers2;
    baseURL: string;
    method: string;
    url: string;
}

export default ApiResponse



