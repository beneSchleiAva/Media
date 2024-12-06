import { Configuration } from "@azure/msal-browser";

const msalConfig: Configuration = {
  auth: {
    clientId: "90f97b5c-5114-4f48-bc7a-4676a26d66bf",
    authority: "https://login.microsoftonline.com/82af2c2c-8383-455a-96a4-19d2d4bebffb",
    redirectUri: "http://localhost:3000",
  },
};

export default msalConfig;