#! /bin/sh

cd /Users/travis/build/andeart/UnityLabs.SystemConsole/SystemConsole.Demo

/Applications/Unity/Unity.app/Contents/MacOS/Unity -batchmode -nographics -runEditorTests -projectPath $(pwd) -logFile $(pwd)/unity.log

echo 'Logs from build'
cat $(pwd)/unity.log