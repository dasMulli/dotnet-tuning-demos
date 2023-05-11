#!/bin/sh

clang sample.c -o sample -lSampleLib -L. -Wl,-rpath,.
