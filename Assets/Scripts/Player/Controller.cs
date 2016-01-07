﻿using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Timers;
using TeamUtility.IO;

namespace Assets.Scripts.Player
{
    /// <summary>
    /// This class wil manage all the player's (and enemy's) components,
    /// such as movement, data , etc
    /// Will also allow the different components to talk to one another
    /// </summary>
    public class Controller : MonoBehaviour
    {
        protected float shake, maxShake = 0.5f;
        // ID for identifying which player is accepting input
        [SerializeField]
        protected PlayerID id;

        // List of timers for checking effects
        protected List<Timer> effectTimers;

        // Distance from firePoint to player
        protected float distanceToPlayer = 1.5f;

        // Componenets to manage
        protected Parkour parkour;
        protected Life life;
        protected Archery archery;
        protected Profile profile;

        void Start()
        {
            // Initialize the effect timers list
            effectTimers = new List<Timer>();

            // Init all componenets
            InitializePlayerComponents();
        }

        /// <summary>
        /// Assigning references
        /// </summary>
        protected virtual void InitializePlayerComponents()
        {
            // Add all components to manage
            life = GetComponent<Life>();
            parkour = GetComponent<Parkour>();
            archery = GetComponent<Archery>();
            profile = GetComponent<Profile>();

            // Tell all components this is their controller
            life.Controller = this;
            parkour.Controller = this;
            archery.Controller = this;
            profile.Controller = this;
        }

        /// <summary>
        /// Disables the player
        /// </summary>
        public void Disable()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Reenables the player
        /// </summary>
        public void Enable()
        {
            gameObject.SetActive(true);
        }

        #region C# Properties
        /// <summary>
        /// Archery component of the player
        /// </summary>
        public Archery ArcheryComponent
        {
            get { return archery; }
        }
        /// <summary>
        /// Life component of the player
        /// </summary>
        public Life LifeComponent
        {
            get { return life; }
        }
        /// <summary>
        /// Parkour component of the player
        /// </summary>
        public Parkour ParkourComponent
        {
            get { return parkour; }
        }
        /// <summary>
        /// Profile component of the player
        /// </summary>
        public Profile ProfileComponent
        {
            get { return profile; }
        }
        /// <summary>
        /// ID of the player
        /// </summary>
        public PlayerID ID
        {
            get { return id; }
        }
        #endregion
    }
}