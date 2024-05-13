#!/bin/bash

LAUNCH_DIRECTORY=${PWD}
WORKING_DIRECTORY=$(dirname $0)/../
SCRIPT_NAME=$(basename $0)

cd $WORKING_DIRECTORY
dotnet build --configuration Release
cd $LAUNCH_DIRECTORY
