using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace TeacherPhilTools
{
    class XMLUtil
    {
        // CombatMove stuff
        //List<CombatMove> lstCombatMoves;
        //private const string XML_MOVE_FILEPATH = "GameRuleData/CombatMoves.xml";
        //private const string XML_MOVE_NAME = "Name";
        //private const string XML_MOVE_MP = "MP";
        //private const string XML_MOVE_ELEMENT = "Element";
        //private const string XML_MOVE_DESC = "FlavourText";
        //private const string XML_MOVE_ACCURACY = "Accuracy";
        //private const string XML_MOVE_Power = "Power";
        //private const string XML_MOVE_MULTIHIT = "MultiHit";
        //private const string XML_MOVE_CRITPLUS = "CritPlus";
        //private const string XML_MOVE_ADDITIONALEFFECT = "AdditionalEffect";
        //private const string XML_MOVE_EFFECTCHANCE = "AdditionalEffectChance";
        //private const string XML_MOVE_RECOIL = "RecoilDamage";
        //private const string XML_MOVE_DRAIN = "Drain";
        //private const string XML_MOVE_CUSTOM = "Custom";

        //Validation valCheck = new Validation();

        //public XMLUtil()
        //{
        //    // now we grab lists
        //    //lstCombatMoves = ReadCombatMoveXMLFile(AppDomain.CurrentDomain.BaseDirectory + XML_MOVE_FILEPATH);
        //}

        //private bool MoveStringToBool(string strInput)
        //{
        //    if (strInput.Equals("0"))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //private List<CombatMove> ReadCombatMoveXMLFile(string strFilePath)
        //{
        //    List<CombatMove> lstCombatMovesXML = new List<CombatMove>();

        //    // all elements to make a move
        //    string strName;
        //    int intMaxPP;
        //    string strType;
        //    string strFlavourText;
        //    int intAccuracy;
        //    int intPower;
        //    //bool booUseSpecialStat;
        //    int intMultiHit;
        //    bool booMoreCritChance;
        //    string strAdditionalEffect;
        //    int intAdditionalEffectChance;
        //    int intRecoilDamage;
        //    int intDrain;
        //    bool booCustomMove;

        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(strFilePath);

        //    XmlNodeList nodes = doc.DocumentElement.SelectNodes("/MoveDefinitions/Move");

        //    foreach (XmlNode node in nodes)
        //    {
        //        // get values from XML
        //        strName = node.SelectSingleNode(XML_MOVE_NAME).InnerText;
        //        intMaxPP = int.Parse(node.SelectSingleNode(XML_MOVE_MP).InnerText);
        //        strType = node.SelectSingleNode(XML_MOVE_ELEMENT).InnerText;
        //        strFlavourText = node.SelectSingleNode(XML_MOVE_DESC).InnerText;
        //        intAccuracy = int.Parse(node.SelectSingleNode(XML_MOVE_ACCURACY).InnerText);
        //        intPower = int.Parse(node.SelectSingleNode(XML_MOVE_Power).InnerText);
        //        //booUseSpecialStat = MoveStringToBool(node.SelectSingleNode(XML_MOVE_SPECIAL).InnerText);
        //        intMultiHit = int.Parse(node.SelectSingleNode(XML_MOVE_MULTIHIT).InnerText);
        //        booMoreCritChance = MoveStringToBool(node.SelectSingleNode(XML_MOVE_CRITPLUS).InnerText);
        //        strAdditionalEffect = node.SelectSingleNode(XML_MOVE_ADDITIONALEFFECT).InnerText;
        //        intAdditionalEffectChance = int.Parse(node.SelectSingleNode(XML_MOVE_EFFECTCHANCE).InnerText);
        //        intRecoilDamage = int.Parse(node.SelectSingleNode(XML_MOVE_RECOIL).InnerText);
        //        intDrain = int.Parse(node.SelectSingleNode(XML_MOVE_DRAIN).InnerText);
        //        booCustomMove = MoveStringToBool(node.SelectSingleNode(XML_MOVE_CUSTOM).InnerText);

        //        // put value into CombatMove instance
        //        CombatMove combatMoveXML = new CombatMove(strName, intMaxPP, strType, strFlavourText, intAccuracy, intPower, intMultiHit, booMoreCritChance, strAdditionalEffect, intAdditionalEffectChance, intRecoilDamage, intDrain, booCustomMove);
        //        // add CombatMove to list
        //        lstCombatMovesXML.Add(combatMoveXML);
        //    }

        //    return lstCombatMovesXML;
        //}

        //public List<CombatMove> GetCombatMoves()
        //{
        //    return lstCombatMoves;
        //}

        //public CombatMove[] GetCombatMovesArr()
        //{
        //    return lstCombatMoves.ToArray();
        //}

        //public GameRuleSet ReadRuleSetFile(string strFile)
        //{
        //    int intMaxIndividualStat = -999;
        //    int intMaxLevel = -999;
        //    int intStatsPerLevel = -999;
        //    int intXPtoLevelUp = -999;
        //    int intHPMultiplier = -999;
        //    int intMPMultiplier = -999;
        //    int intAttackSpeedGrowth = -999;
        //    int intInitialGold = -999;

        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(strFile);

        //    XmlNodeList nodes = doc.DocumentElement.SelectNodes("/rules/ruleset");

        //    foreach (XmlNode node in nodes)
        //    {
        //        string strMaxIndividualStat = node.SelectSingleNode("MaxIndividualStat").InnerText;
        //        string strMaxLevel = node.SelectSingleNode("MaxLevel").InnerText;
        //        string strStatsPerLevel = node.SelectSingleNode("StatsPerLevel").InnerText;
        //        string strXPtoLevelUp = node.SelectSingleNode("XPtoLevelUp").InnerText;
        //        string strHPMultiplier = node.SelectSingleNode("HPMultiplier").InnerText;
        //        string strMPMultiplier = node.SelectSingleNode("MPMultiplier").InnerText;
        //        string strAttackSpeedGrowth = node.SelectSingleNode("AttackSpeedGrowth").InnerText;
        //        string strInitialGold = node.SelectSingleNode("InitialGold").InnerText;

        //        // convert appropriate nodes to ints
        //        intMaxIndividualStat = int.Parse(strMaxIndividualStat);
        //        intMaxLevel = int.Parse(strMaxLevel);
        //        intStatsPerLevel = int.Parse(strStatsPerLevel);
        //        intXPtoLevelUp = int.Parse(strXPtoLevelUp);
        //        intHPMultiplier = int.Parse(strHPMultiplier);
        //        intMPMultiplier = int.Parse(strMPMultiplier);
        //        intAttackSpeedGrowth = int.Parse(strAttackSpeedGrowth);
        //        intInitialGold = int.Parse(strInitialGold);
        //    }

        //    GameRuleSet gameRuleSet = new GameRuleSet(intMaxIndividualStat, intMaxLevel, intStatsPerLevel, intXPtoLevelUp, intHPMultiplier, intMPMultiplier, intAttackSpeedGrowth, intInitialGold);
        //    return gameRuleSet;
        //}
    }
}
