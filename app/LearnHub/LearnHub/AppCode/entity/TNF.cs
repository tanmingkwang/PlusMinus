﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnHub.AppCode.entity
{
    public class TNF
    {
        //to add in when confirmed fields
        private int tnfid;
        private User user;
        private List<User> users;
        private string type;
        private string status;
        private int wf_status;
        private Workflow wf;
        private WorkflowSub wfs;
        private DateTime applicationDate;

        public TNF() { }

        public TNF(User user, string type, string status, int wf_status, Workflow wf, DateTime applicationDate)
        {
            this.user = user;
            this.type = type;
            this.status = status;
            this.wf_status = wf_status;
            this.wf = wf;
            this.applicationDate = applicationDate;
        }
        public TNF(List<User> users, string type, string status, int wf_status, Workflow wf, DateTime applicationDate)
        {
            this.users = users;
            this.type = type;
            this.status = status;
            this.wf_status = wf_status;
            this.wf = wf;
            this.applicationDate = applicationDate;
        }
        public int getTNFID()
        {
            return tnfid;
        }
        public void setTNFID(int tnfid)
        {
            this.tnfid = tnfid;
        }
        public string getType()
        {
            return type;
        }
        public void setType(string type)
        {
            this.type = type;
        }
        public string getStatus()
        {
            return status;
        }
        public void setStatus(string status)
        {
            this.status = status;
        }
        public User getUser()
        {
            return user;
        }
        public void setUser(User user)
        {
            this.user = user;
        }
        public List<User> getUsers()
        {
            return users;
        }
        public void setUsers(List<User> users)
        {
            this.users = users;
        }
        public int getWFStatus()
        {
            return wf_status;
        }
        public void setWFStatus(int wf_status)
        {
            this.wf_status = wf_status;
        }
        public Workflow getWorkflow()
        {
            return wf;
        }
        public void setWorkflow(Workflow wf)
        {
            this.wf = wf;
        }
        public WorkflowSub getWorkflowSub()
        {
            return wfs;
        }
        public void setWorkflowSub(WorkflowSub wfs)
        {
            this.wfs = wfs;
        }
        public DateTime getApplicationDate()
        {
            return applicationDate;
        }
        public void setApplicationDate(DateTime applicationDate)
        {
            this.applicationDate = applicationDate;
        }
    }
}