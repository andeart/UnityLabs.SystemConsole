#!/usr/bin/env bash

set -e
set -x
set +x
echo 'Writing $UNITY_LICENSE_CONTENT to license file to ${TRAVIS_BUILD_DIR}/Unity_lic.ulf'
echo "$UNITY_LICENSE_CONTENT" | tr -d '\r' > ${TRAVIS_BUILD_DIR}/Unity_lic.ulf
