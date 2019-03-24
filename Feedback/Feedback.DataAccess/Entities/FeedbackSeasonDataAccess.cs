﻿using Feedback.DomainModel;
using Feedback.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feedback.DataAccess.Entities
{
    public class FeedbackSeasonDataAccess : BaseDataAccess<FeedbackSeason>
    {
        public FeedbackSeasonDataAccess(ApplicationContext ctx) : base(ctx) { }
        
    }
}
