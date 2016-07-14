# Common.Configuration
Simple app and web config wrapper for .net

The main benefit is it lets developers create configurable options without reasonable defaults.

```var codeName = ConfigHelper.GetAppSetting<string>("code-name", "duchess");```

So if you have a config value of:
```<add key="code-name" value="elvis">```
you get "elvis".  If you delete that key, you get "duchess"


```var volume = ConfigHelper.GetAppSetting<string>("volume-level", 11);```

defaults to 11, or pulls from config.

