#! /bin/sh

echo "Running Unity"
export UNITY_EXECUTABLE=${UNITY_EXECUTABLE:-"/Applications/Unity/Unity.app/Contents/MacOS/Unity"}

cd /Users/travis/build/andeart/UnityLabs.SystemConsole/SystemConsole.Demo


${UNITY_EXECUTABLE:-xvfb-run --auto-servernum --server-args='-screen 0 640x480x24' /opt/Unity/Editor/Unity} -batchmode -nographics -runEditorTests -projectPath $(pwd) -logFile $(pwd)/unity.log

echo "Logs from build"
cat $(pwd)/unity.log