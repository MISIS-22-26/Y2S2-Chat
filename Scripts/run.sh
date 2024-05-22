#!/bin/bash

LAUNCH_DIRECTORY=${PWD}
WORKING_DIRECTORY=$(dirname $0)/../
SCRIPT_NAME=$(basename $0)

cd $WORKING_DIRECTORY
./bin/client/Cappa-Chat
cd $LAUNCH_DIRECTORY
