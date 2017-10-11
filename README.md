# Common.Configuration
This is a very simple wrapper library to make reading web.config or app.config trivially easy.  

##Benefits:
- Automatically casting config values to common types
- Supports hardcoding a default value that gets overridden if a config value is present.

##Examples:

###Integers:

```Thread.Sleep(ConfigHelper.GetAppSetting<int>("sleep-delay-between-runs", 1000));```

With no configuration value, we sleep for 1000 ms.

If config has an entry like this:

```<add key="sleep-delay-between-runs" value="500">```

We sleep for 500 ms.

###Strings:

```var codeName = ConfigHelper.GetAppSetting<string>("code-name", "duchess");```

Returns "duchess" by default unless there is a config value.

If config has a value of 

```<add key="code-name" value="El Contador">```

it returns "El Contador"




