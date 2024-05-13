#!/bin/bash

LAUNCH_DIRECTORY=${PWD}
WORKING_DIRECTORY=$(dirname $0)/../
SCRIPT_NAME=$(basename $0)

cd $WORKING_DIRECTORY
case ${1} in 
	"release")
		dotnet publish -c release --self-contained
	;;
	"debug")
		dotnet build
	;;
	*)
		exit 1
	;;
esac
cd $LAUNCH_DIRECTORY
