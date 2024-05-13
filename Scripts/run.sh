#!/bin/bash

LAUNCH_DIRECTORY=${PWD}
WORKING_DIRECTORY=$(dirname $0)/../
SCRIPT_NAME=$(basename $0)

cd $WORKING_DIRECTORY
case ${1} in 
	"release")
		./bin/release/net8.0/linux-x64/Cappa-Chat
	;;
	"debug")
		dotnet run
	;;
	*)
		exit 1
	;;
esac
cd $LAUNCH_DIRECTORY
