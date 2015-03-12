// Learn more about F# at http://fsharp.net. See the 'F# Tutorial' project
// for more guidance on F# programming.
#r @"bin/Debug/FLib.dll"

#load "Library1.fs"
open CompileFsx
open FLib

test1 (Data "foo")
// Define your library scripting code here