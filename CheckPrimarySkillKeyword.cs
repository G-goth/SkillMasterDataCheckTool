using System;
using System.Collections.Generic;

interface ICheckSkillMisMatch
{
    void CheckSkillOverLapping(string[,] skillDataList);
    void CheckSkillBlank(string[,] skillDataList);
    void CheckSkillFullWidth(string[,] skillDataList);
}

class CheckPrimarySkillKeyword : ICheckSkillMisMatch
{
    public void CheckSkillOverLapping(string[,] skillDataList)
    {}
    public void CheckSkillBlank(string[,] skillDataList)
    {}
    public void CheckSkillFullWidth(string[,] skillDataList)
    {}
}