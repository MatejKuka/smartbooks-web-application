import ReactDOM from 'react-dom/client';
import "./index.css";
import App from './App.js';
import {BrowserRouter} from 'react-router-dom';
import {QueryClient, QueryClientProvider} from 'react-query'
import {CoursesContextProvider} from "./context/courses-context.tsx";

const queryClient = new QueryClient();

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <QueryClientProvider client={queryClient}>
        <BrowserRouter>
            <CoursesContextProvider>
                <App/>
            </CoursesContextProvider>
        </BrowserRouter>
    </QueryClientProvider>
);
