﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Dian.Common.Entity;
using Dian.Common.Interface;
using Dian.Dao;
using CSN.DotNetLibrary.EntityExpressions.Entitys;

namespace Dian.Biz
{
    public class FoodTypeBiz : System.MarshalByRefObject, IFoodType
    {
        private DianManual _manual_dao = null;
        public DianManual manual_dao
        {
            get
            {
                return _manual_dao == null ? _manual_dao = new DianManual() : _manual_dao;
            }
        }

        public DataTable GetFoodTypeDataTable()
        {
            try
            {
                return manual_dao.GetFoodTypeDataTable();
            }
            catch (Exception ex)
            {
                throw new DianBizException("获取店的数据出错！", ex);
            }
        }
        public List<FoodTypeEntity> GetFoodTypeEntityList(FoodTypeEntity condition_entity)
        {
            try
            {
                GenericWhereEntity<FoodTypeEntity> where_entity = new GenericWhereEntity<FoodTypeEntity>();
                if (condition_entity.FOOD_TYPE_ID != null)
                    where_entity.Where(n => (n.FOOD_TYPE_ID == condition_entity.FOOD_TYPE_ID));
                if (condition_entity.FOOD_TYPE_NAME != null)
                    where_entity.Where(n => (n.FOOD_TYPE_NAME == condition_entity.FOOD_TYPE_NAME));
                return DianDao.ReadEntityList(where_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("获取店的数据出错！", ex);
            }
        }
        public void InsertFoodTypeEntity(FoodTypeEntity condition_entity)
        {
            try
            {
                DianDao.InsertEntity(condition_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("插入店数据出错！", ex);
            }

        }
        public void UpdateFoodTypeEntity(FoodTypeEntity condition_entity)
        {
            try
            {
                DianDao.UpdateEntity(condition_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("更新店数据出错！", ex);
            }

        }
        public void DeleteFoodTypeEntity(FoodTypeEntity condition_entity)
        {
            try
            {
                DianDao.DeleteEntity(condition_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("删除店数据出错！", ex);
            }

        }
        public FoodTypeEntity GetFoodTypeEntity(int? id)
        {
            return DianDao.ReadEntity2<FoodTypeEntity>(n => n.FOOD_TYPE_ID == id);
        }

        public int TestCallAble()
        {
            throw new NotImplementedException();
        }
    }
}
