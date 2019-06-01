#! /bin/sh

echo "Running Unity"
set -x

UNITY_EXECUTABLE="/Applications/Unity/Unity.app/Contents/MacOS/Unity"

TEST_PLATFORM=editmode

echo "Activating license"

${UNITY_EXECUTABLE} -batchmode -manualLicenseFile ${TRAVIS_BUILD_DIR}/Unity_lic.ulf -logFile "${TRAVIS_BUILD_DIR}/unity.activation.log"
echo "Unity activation log"
cat "${TRAVIS_BUILD_DIR}/unity.activation.log"

echo "Testing for $TEST_PLATFORM"

${UNITY_EXECUTABLE} \
  -projectPath $(pwd) \
  -runTests \
  -testPlatform $TEST_PLATFORM \
  -testResults $(pwd)/$TEST_PLATFORM-results.xml \
  -logFile \
  -batchmode

UNITY_EXIT_CODE=$?

if [ $UNITY_EXIT_CODE -eq 0 ]; then
  echo "Run succeeded, no failures occurred";
elif [ $UNITY_EXIT_CODE -eq 2 ]; then
  echo "Run succeeded, some tests failed";
elif [ $UNITY_EXIT_CODE -eq 3 ]; then
  echo "Run failure (other failure)";
else
  echo "Unexpected exit code $UNITY_EXIT_CODE";
fi

cat $(pwd)/$TEST_PLATFORM-results.xml | grep test-run | grep Passed

echo "Returning license"
/Applications/Unity/Unity.app/Contents/MacOS/Unity -quit -batchmode -returnlicense
${UNITY_EXECUTABLE} \
        -logFile "${TRAVIS_BUILD_DIR}/unity.returnlicense.log" \
        -batchmode \
        -returnlicense \
        -quit
echo "Unity return license log"
cat "${TRAVIS_BUILD_DIR}/unity.returnlicense.log"

exit $UNITY_TEST_EXIT_CODE
