# Common.Configuration
This is a very simple wrapper library to make reading web.config or app.config trivially easy.  

Benefits:
- Automatically casting config values to common types
- Supports hardcoding a default value that gets overridden if a config value is present.

Examples:
```Thread.Sleep(ConfigHelper.GetAppSetting<int>("sleep-delay-between-runs", 1000));```

Returns and int of 1000 if there is no config value specified.

If config has an entry like this:

```<add key="sleep-delay-between-runs" value="500">```

it returns 500.


```var codeName = ConfigHelper.GetAppSetting<string>("code-name", "duchess");```

Returns "duchess" by default unless there is a config value.

If config has a value of 

```<add key="code-name" value="El Contador">```

it returns "El Contador"




