using System;
using System.Collections.Generic;

interface ICheckSkillMisMatch
{
    void CheckSkillOverLap(string[,] skillDataList);
    void CheckSkillBlank(string[,] skillDataList);
    void CheckSkillFullWidthHalfWidth(string[,] skillDataList);
}

class CheckPrimarySkillKeyword : ICheckSkillMisMatch
{
    public void CheckSkillOverLap(string[,] skillDataList)
    {}
    public void CheckSkillBlank(string[,] skillDataList)
    {}
    public void CheckSkillFullWidthHalfWidth(string[,] skillDataList)
    {}
}