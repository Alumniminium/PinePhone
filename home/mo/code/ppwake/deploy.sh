#!/bin/bash

dotnet build
rsync -r bin/Debug/net5.0/ mo@192.168.0.6:/home/mo/ppwake