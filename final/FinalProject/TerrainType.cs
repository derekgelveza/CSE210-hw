using System;
using System.ComponentModel;

public enum TerrainType
{
    [Description("The ancient, sun-dappled home of the elves")]
    GROVE,

    [Description("A modest clearing with smoldering embers and tattered tents")]
    CAMP,

    [Description("Jagged, snow-capped peaks that pierce the clouds")]
    MOUNTAIN,

    [Description("A chaotic sprawl of scrap-wood huts and the smell of rot")]
    GOBLINCAMP,

    [Description("A dense thicket of towering oaks and tangled brambles")]
    FOREST,

    [Description("Weathered planks creaking over the rhythmic lap of the tide")]
    DOCK,

    [Description("A lonely, dust-covered retreat built from sturdy wood")]
    CABIN,

    [Description("A small cave")]
    CAVE,

    [Description("A very, VERY dry desert")]
    DESERT
}