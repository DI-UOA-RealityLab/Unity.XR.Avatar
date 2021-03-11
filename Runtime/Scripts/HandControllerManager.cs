namespace DI.UOA.RealityLab.Unity.XR.Avatar {

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.XR;

    public class HandControllerManager : MonoBehaviour
    {
        public List<GameObject> controllerPrefabs;
        public GameObject handPrefab;
        public InputDeviceCharacteristics targetDeviceCharacteristics;
        public bool showController;
        public bool useComplexHandAnimation;

        List<InputDevice> devices;
        InputDevice targetDevice;
        GameObject spawnedController;
        GameObject spawnedHand;
        Animator handAnimator;

        // Start is called before the first frame update
        void Start()
        {
            devices = new List<InputDevice>();

            Initialize();
        }

        void Initialize()
        {
            refreshAvailableDevices();

            if (devices.Count > 0)
            {
                targetDevice = devices[0];

                GameObject controllerPrefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
                if (!controllerPrefab)
                {
                    controllerPrefab = controllerPrefabs[0];
                }

                spawnedController = Instantiate(controllerPrefab, transform);
            }

            if (spawnedHand == null)
            {
                spawnedHand = Instantiate(handPrefab, transform);
                handAnimator = spawnedHand.GetComponent<Animator>();
            }
        }

        void refreshAvailableDevices()
        {
            InputDevices.GetDevicesWithCharacteristics(targetDeviceCharacteristics, devices);
        }

        // Update is called once per frame
        void Update()
        {
            if (targetDevice.isValid)
            {
                if (showController)
                {
                    spawnedController.SetActive(true);
                    spawnedHand.SetActive(false);
                }
                else
                {
                    spawnedController.SetActive(false);
                    spawnedHand.SetActive(true);

                    if (useComplexHandAnimation)
                    {
                        UpdateHandAnimationComplex();
                    }
                    else
                    {
                        UpdateHandAnimation();
                    }
                }
            }
            else
            {
                Initialize();
            }
        }

        void UpdateHandAnimation()
        {
            if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            {
                handAnimator.SetFloat("Grip", gripValue);
            }
            else
            {
                handAnimator.SetFloat("Grip", 0f);
            }

            if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
            {
                handAnimator.SetFloat("Trigger", triggerValue);
            }
            else
            {
                handAnimator.SetFloat("Trigger", 0f);
            }
        }

        void UpdateHandAnimationComplex()
        {
            if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            {
                handAnimator.SetFloat("Middle", gripValue);
                handAnimator.SetFloat("Ring", gripValue);
                handAnimator.SetFloat("Pinky", gripValue);
            }
            else
            {
                handAnimator.SetFloat("Middle", 0f);
                handAnimator.SetFloat("Ring", 0f);
                handAnimator.SetFloat("Pinky", 0f);
            }

            if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
            {
                handAnimator.SetFloat("Index", triggerValue);
            }
            else
            {
                handAnimator.SetFloat("Index", 0f);
            }

            targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool primary2DAxisTouch);
            targetDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool primaryTouch);
            targetDevice.TryGetFeatureValue(CommonUsages.secondary2DAxisTouch, out bool secondary2DAxisTouch);
            targetDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool secondaryTouch);
            if (primary2DAxisTouch || primaryTouch || secondary2DAxisTouch || secondaryTouch)
            {
                handAnimator.SetFloat("Thumb", 1f);
            }
            else
            {
                handAnimator.SetFloat("Thumb", 0f);
            }
        }
    }
}
