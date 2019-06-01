#! /bin/sh

echo "Running Unity"
UNITY_PATH="/Applications/Unity/Unity.app/Contents/MacOS/Unity"

cd /Users/travis/build/andeart/UnityLabs.SystemConsole/SystemConsole.Demo

activateLicense() {
    echo "Activating Unity..."

    ${UNITY_PATH} \
        -logFile "${TRAVIS_BUILD_DIR}/unity.activation.log" \
        -username "${UNITY_USER}" \
        -password "${UNITY_PWD}" \
        -batchmode \
        -noUpm \
        -quit
    echo "Unity activation log"
    cat "${TRAVIS_BUILD_DIR}/unity.activation.log"
}

returnLicense() {
    echo "Return license"

    ${UNITY_PATH} \
        -logFile "${TRAVIS_BUILD_DIR}/unity.returnlicense.log" \
        -batchmode \
        -returnlicense \
        -quit
    echo "Unity return license log"
    cat "$(pwd)/unity.returnlicense.log"
}


unitTests() {
    echo "Running editor unit tests for ${UNITY_PROJECT_NAME}"

    ${UNITY_PATH} \
        -batchmode \
        -username "${UNITY_USER}" \
        -password "${UNITY_PWD}" \
        -logFile "${TRAVIS_BUILD_DIR}/unity.unittests.log" \
        -projectPath $(pwd) \
        -runEditorTests \
        -editorTestsResultFile "${TRAVIS_BUILD_DIR}/unity.unittests.xml"

    rc0=$?
    echo "Unit test log"
    cat "${TRAVIS_BUILD_DIR}/unity.unittests.xml"

    # exit if tests failed
    if [ $rc0 -ne 0 ]; then { echo "Unit tests failed"; exit $rc0; } fi
}

oldUnitTests() {
    ${UNITY_PATH} -batchmode -runEditorTests -projectPath $(pwd) -logFile $(pwd)/unity.log

    echo "Logs from build"
    cat $(pwd)/unity.log
}

activateLicense
unitTests

exit 0