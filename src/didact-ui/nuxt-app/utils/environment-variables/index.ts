import axios from "axios";
import { isDev } from "../environment";

const devBaseUrl: string = import.meta.env.VITE_ENVIRONMENT_VARIABLES_DEV_BASE_URL;

interface EnvironmentVariables {
    didactEngineBaseUrl: string
}

/**
 * Determines the appropriate base URL for the runtime environment variables depending on how the single page app is currently running.
 * @returns 
 */
const getBaseUrlForEnvironmentVariables = () => {
    return isDev() ? devBaseUrl : '';
}

/**
 * Gets the dynamic set of runtime environment variables from the containing dotnet web api that serves this single page app.
 * @returns {EnvironmentVariables}
 */
const getEnvironmentVariables = async () : Promise<EnvironmentVariables> => {
    const baseUrl = getBaseUrlForEnvironmentVariables();
    const response = await axios.get<EnvironmentVariables>(`${baseUrl}/environment-variables`);
    return response.data;
}

export { getEnvironmentVariables }