import { BrowserCacheLocation, LogLevel } from '@azure/msal-browser';

export const authConfig = {
  auth: {
    clientId: 'your client id',
    authority: 'your authority url',
    tenantId:'your tenant id',
    redirectUri: 'your redirect url',
    postLogoutRedirectUri: "Logout redirect url",
  },
  cache: {
    cacheLocation: BrowserCacheLocation.SessionStorage,
    storeAuthStateInCookie: true,
  },
  system: {
    loggerOptions: {
        loggerCallback: (level, message, containsPii) => {
            if (containsPii) return;
            level = LogLevel.Verbose;

            switch (level) {
                case LogLevel.Error:
                    console.error(message);
                    return;
                case LogLevel.Info:
                    console.info(message);
                    return;
                case LogLevel.Verbose:
                    console.debug(message);
                    return;
                case LogLevel.Warning:
                    console.warn(message);
                    return;
                default:
                    console.log(message);
            }
        }
    }
}
};


export const request = {
  scopes: ['user.read'],
};
