#!/bin/bash


LAUNCH_DIRECTORY=${PWD}
WORKING_DIRECTORY=$(dirname $0)/../
SCRIPT_NAME=$(basename $0)

cd $WORKING_DIRECTORY
dotnet publish -c release --self-contained -o "bin/client"
cd $LAUNCH_DIRECTORY