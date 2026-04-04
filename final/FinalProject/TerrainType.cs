using System;
using System.ComponentModel;

public enum TerrainType
{
    [Description("The ancient, sun-dappled home of the elves")]
    Grove,

    [Description("A modest clearing with smoldering embers and tattered tents")]
    Camp,

    [Description("Jagged, snow-capped peaks that pierce the clouds")]
    Mountain,

    [Description("A chaotic sprawl of scrap-wood huts and the smell of rot")]
    GoblinCamp,

    [Description("A dense thicket of towering oaks and tangled brambles")]
    Forest,

    [Description("Weathered planks creaking over the rhythmic lap of the tide")]
    Dock,

    [Description("A lonely, dust-covered retreat built from sturdy wood")]
    Cabin,

    [Description("A small cave")]
    Cave,

    [Description("A very, VERY dry desert")]
    Desert
}
