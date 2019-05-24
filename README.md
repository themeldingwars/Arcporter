
# Arcporter

*This tool was created for educational purposes only and should not be used by anyone.*

This tool lets you load into any Firefall zone in replay mode and it removes the range limit on the spectator camera.

Arcporter is still in early development and is only confirmed working with the latest game client, but it should in theory work with earlier clients as well.

![](https://forums.themeldingwars.com/assets/uploads/files/arcporter.png)

## How to Install

1. Grab the [latest release](https://github.com/themeldingwars/Arcporter/releases) from GitHub
2. Don't start Firefall manually
3. Launch Arcporter
4. Pick the FirefallClient.exe
5. Select the zone you want to explore
6. Have fun!

## How to Build

This repository is using submodules, so in order to properly clone it use this:

```
git clone --recurse-submodules https://github.com/themeldingwars/Arcporter.git
```

If you already cloned the repo or are using an older version than 2.13 of git, use this to grab the needed submodules:

```
git clone https://github.com/themeldingwars/Arcporter.git
cd Arcporter
git submodule update --init --recursive
```
