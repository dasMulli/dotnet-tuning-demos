#!/bin/sh

clang sample.c -o sample -L. -lSampleLib -Wl,-rpath,.
